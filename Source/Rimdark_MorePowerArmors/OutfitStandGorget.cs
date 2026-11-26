using System.Collections;
using Core40k;
using Genes40k;
using HarmonyLib;
using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;
using Verse;

namespace Rimdark_MorePowerArmors
{
    [HarmonyPatch(typeof(Building_OutfitStand), "RecacheGraphics")]
    public static class OutfitStandGorget
    {
        private const int GorgetTextureIdentifier = 3;

#if RIMWORLD_1_7
        private static readonly ConstructorInfo CachedGraphicRenderInfoConstructor =
            typeof(Building_OutfitStand).GetNestedType(
                "CachedGraphicRenderInfo",
                BindingFlags.NonPublic).GetConstructor(
                BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic,
                null,
                new[] { typeof(Graphic), typeof(int), typeof(Vector3), typeof(Vector3) },
                null);
#endif

        public static void Postfix(
            Building_OutfitStand __instance,
            ThingOwner<Thing> ___innerContainer,
#if RIMWORLD_1_7
            IList ___cachedApparelGraphicsNonHeadgear)
#else
            List<CachedGraphicRenderInfo> ___cachedApparelGraphicsNonHeadgear)
#endif
        {
            foreach (Apparel apparel in ___innerContainer.InnerListForReading.OfType<Apparel>())
            {
                CompChapterColorWithShoulderDecoration comp =
                    apparel.GetComp<CompChapterColorWithShoulderDecoration>();
                if (comp == null)
                {
                    continue;
                }

                DefModExtension_TextureFlags textureFlags =
                    apparel.def.GetModExtension<DefModExtension_TextureFlags>();

                foreach (PawnRenderNodeProperties props in apparel.def.apparel.RenderNodeProperties)
                {
                    if (string.IsNullOrEmpty(props.texPath) ||
                        props.texPath.IndexOf("_Gorget", StringComparison.OrdinalIgnoreCase) < 0)
                    {
                        continue;
                    }

                    string maskPath = null;
                    if (comp.MaskDef != null &&
                        textureFlags != null &&
                        textureFlags.ShouldExpandMaskPath(comp.MaskDef, GorgetTextureIdentifier))
                    {
                        maskPath = comp.MaskDef.maskPath +
                            textureFlags.GetExpansionPathByIdentifier(GorgetTextureIdentifier);
                    }

                    Shader shader = Core40kDefOf.BEWH_CutoutThreeColor.Shader;
                    Graphic_Multi graphic = MultiColorUtils.GetGraphic<Graphic_Multi>(
                        props.texPath,
                        shader,
                        props.drawSize,
                        comp.DrawColor,
                        comp.DrawColorTwo,
                        comp.DrawColorThree,
                        apparel.def.graphicData,
                        maskPath);

                    int layer = (int)props.drawData.LayerForRot(
                        __instance.Rotation,
                        (int)props.baseLayer);

                    Vector3 offset = Vector3.zero;
                    if (__instance.Rotation == Rot4.North ||
                        __instance.Rotation == Rot4.West ||
                        __instance.Rotation == Rot4.East)
                    {
                        offset.y = BodyTypeDefOf.Hulk.headOffset.y;
                    }

#if RIMWORLD_1_7
                    ___cachedApparelGraphicsNonHeadgear.Add(
                        CachedGraphicRenderInfoConstructor.Invoke(
                            new object[] { graphic, layer, Vector3.one, offset }));
#else
                    ___cachedApparelGraphicsNonHeadgear.Add(
                        new CachedGraphicRenderInfo(graphic, layer, Vector3.one, offset));
#endif
                }
            }
        }
    }
}
