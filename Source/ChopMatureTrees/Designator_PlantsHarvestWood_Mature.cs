﻿/*
 * Created by SharpDevelop.
 * User: Tobias
 * Date: 05.08.2018
 * Time: 20:34
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using Verse;
using RimWorld;
using UnityEngine;


namespace MoreHarvestDesignators
{
	/// <summary>
	/// Description of MyClass.
	/// </summary>
	public class Designator_PlantsHarvestWood_Mature : Designator_Plants
	{
		public Designator_PlantsHarvestWood_Mature()
		{
			this.defaultLabel = "Designator_PlantsHarvestWood_Mature_label".Translate();
			this.defaultDesc = "Designator_PlantsHarvestWood_Mature_desc".Translate();
			this.icon = ContentFinder<Texture2D>.Get("UI/Designators/HarvestWood", true);
			this.soundDragSustain = SoundDefOf.Designate_DragStandard;
			this.soundDragChanged = SoundDefOf.Designate_DragStandard_Changed;
			this.useMouseIcon = true;
			this.soundSucceeded = SoundDefOf.Designate_Harvest;
			this.hotKey = KeyBindingDefOf.Misc1;
			this.designationDef = DesignationDefOf.HarvestPlant;
			this.tutorTag = "PlantsHarvestWood";
		}

		public override AcceptanceReport CanDesignateThing(Thing t)
		{
			AcceptanceReport acceptanceReport = base.CanDesignateThing(t);
			AcceptanceReport result;
			if (!acceptanceReport.Accepted)
			{
				result = acceptanceReport;
			}
			else
			{
				Plant plant = (Plant)t;
				if (!plant.HarvestableNow || plant.def.plant.harvestTag != "Wood" || plant.Growth < 0.999f)
				{
					result = "Designator_PlantsHarvestWood_Mature_Rejected".Translate();
				}
				else
				{
					result = true;
				}
			}
			return result;
		}

		protected override bool RemoveAllDesignationsAffects(LocalTargetInfo target)
		{
			return target.Thing.def.plant.harvestTag == "Wood";
		}
	}
}