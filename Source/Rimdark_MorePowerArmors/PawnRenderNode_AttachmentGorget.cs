using Core40k;
using RimWorld;
using System.Collections.Generic;
using UnityEngine;
using Verse;

namespace Rimdark_MorePowerArmors
{
    internal class PawnRenderNode_AttachmentGorget : PawnRenderNode_Apparel
    {
        private const int GorgetTextureIdentifier = 3;

        public PawnRenderNode_AttachmentGorget(
            Pawn pawn,
            PawnRenderNodeProperties props,
            PawnRenderTree tree)
            : base(pawn, props, tree)
        {
        }

        public override Graphic GraphicFor(Pawn pawn)
        {
            CompMultiColor comp = apparel.GetComp<CompMultiColor>();
            DefModExtension_TextureFlags textureFlags =
                apparel.def.GetModExtension<DefModExtension_TextureFlags>();

            string maskPath = null;
            if (comp.MaskDef != null &&
                textureFlags != null &&
                textureFlags.ShouldExpandMaskPath(comp.MaskDef, GorgetTextureIdentifier))
            {
                maskPath = comp.MaskDef.maskPath +
                    textureFlags.GetExpansionPathByIdentifier(GorgetTextureIdentifier);
            }

            string path = Props.texPath;
            if (Props.bodyTypeGraphicPaths != null)
            {
                foreach (BodyTypeGraphicData data in Props.bodyTypeGraphicPaths)
                {
                    if (pawn.story.bodyType == data.bodyType)
                    {
                        path = data.texturePath;
                        break;
                    }
                }
            }

            Shader shader = Core40kDefOf.BEWH_CutoutThreeColor.Shader;
            return MultiColorUtils.GetGraphic<Graphic_Multi>(
                path,
                shader,
                Props.drawSize,
                comp.DrawColor,
                comp.DrawColorTwo,
                comp.DrawColorThree,
                apparel.def.graphicData,
                maskPath);
        }

        protected override IEnumerable<Graphic> GraphicsFor(Pawn pawn)
        {
            yield return GraphicFor(pawn);
        }
    }
}
