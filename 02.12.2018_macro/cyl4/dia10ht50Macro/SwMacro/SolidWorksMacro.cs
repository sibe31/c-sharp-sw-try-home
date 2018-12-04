using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;
using System.Runtime.InteropServices;
using System;

namespace dia10ht50Macro.csproj
{
    public partial class SolidWorksMacro
    {


        public void Main()
        {

            
            ModelDoc2 swDoc = null;
            
            bool boolstatus = false;
            
            swDoc = ((ModelDoc2)(swApp.ActiveDoc));
            boolstatus = swDoc.Extension.SelectByID2("Top Plane", "PLANE", 0, 0, 0, false, 0, null, 0);
            swDoc.SketchManager.InsertSketch(true);
            swDoc.ClearSelection2(true);
            SketchSegment skSegment = null;
            skSegment = ((SketchSegment)(swDoc.SketchManager.CreateCircle(0, 0, 0, 0.037396, 0.000948, 0)));
            // 
            // Named View
            swDoc.ShowNamedView2("*Trimetric", 8);
            swDoc.ViewZoomtofit2();
            Feature myFeature = null;
            myFeature = ((Feature)(swDoc.FeatureManager.FeatureExtrusion2(true, false, false, 0, 0, 0.05, 0.01, false, false, false, false, 0.26179938779915, 0.26179938779915, false, false, false, false, true, true, true, 0, 0, false)));
            swDoc.ISelectionManager.EnableContourSelection = false;
            boolstatus = swDoc.EditRebuild3();
            swDoc.ClearSelection2(true);
        }

        /// <summary>
        ///  The SldWorks swApp variable is pre-assigned for you.
        /// </summary>
        public SldWorks swApp;
    }
}


