using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;
using System.Runtime.InteropServices;
using System;

namespace Macro1.csproj
{
    public partial class SolidWorksMacro
    {


        public void Main()
        {

            
            ModelDoc2 swDoc = null;
            PartDoc swPart = null;
            DrawingDoc swDrawing = null;
            AssemblyDoc swAssembly = null;
            bool boolstatus = false;
            int longstatus = 0;
            int longwarnings = 0;
            // 
            // New Document
            double swSheetWidth;
            swSheetWidth = 0;
            double swSheetHeight;
            swSheetHeight = 0;
            swDoc = ((ModelDoc2)(swApp.NewDocument("C:\\ProgramData\\SolidWorks\\SOLIDWORKS 2017\\templates\\Part.prtdot", 0, swSheetWidth, swSheetHeight)));
            swPart = swDoc;
            swApp.ActivateDoc2("Part1", false, ref longstatus);
            swDoc = ((ModelDoc2)(swApp.ActiveDoc));
            ModelView myModelView = null;
            myModelView = ((ModelView)(swDoc.ActiveView));
            myModelView.FrameState = ((int)(swWindowState_e.swWindowMaximized));
            boolstatus = swDoc.Extension.SelectByID2("Top Plane", "PLANE", 0, 0, 0, false, 0, null, 0);
            swDoc.SketchManager.InsertSketch(true);
            swDoc.ClearSelection2(true);
            SketchSegment skSegment = null;
            skSegment = ((SketchSegment)(swDoc.SketchManager.CreateCircle(0, 0, 0, 0.034655, 0.000129, 0)));
            swDoc.ClearSelection2(true);
            swDoc.SketchManager.InsertSketch(true);
            // 
            // Named View
            swDoc.ShowNamedView2("*Trimetric", 8);
            swDoc.ViewZoomtofit2();
            Feature myFeature = null;
            myFeature = ((Feature)(swDoc.FeatureManager.FeatureExtrusion2(true, false, false, 0, 0, 0.05, 0.01, false, false, false, false, 0.26179938779915, 0.26179938779915, false, false, false, false, true, true, true, 0, 0, false)));
            swDoc.ISelectionManager.EnableContourSelection = false;
            boolstatus = swDoc.EditRebuild3();
            swDoc.ClearSelection2(true);
            // 
            // Save As
            longstatus = swDoc.SaveAs3("C:\\Users\\SIBERAJA\\Desktop\\SW Check\\02.12.2018_macro\\cylindercheck1\\Part1.SLDPRT", 0, 2);
            // 
            // Close Document
            swPart = null;
            swDoc = null;
            swApp.CloseDoc("Part1");
            // 
            // New Document
            swSheetWidth = 0;
            swSheetHeight = 0;
            swDoc = ((ModelDoc2)(swApp.NewDocument("C:\\ProgramData\\SolidWorks\\SOLIDWORKS 2017\\templates\\Part.prtdot", 0, swSheetWidth, swSheetHeight)));
            swPart = swDoc;
            swApp.ActivateDoc2("Part2", false, ref longstatus);
            swDoc = ((ModelDoc2)(swApp.ActiveDoc));
            myModelView = ((ModelView)(swDoc.ActiveView));
            myModelView.FrameState = ((int)(swWindowState_e.swWindowMaximized));
            swDoc = ((ModelDoc2)(swApp.ActiveDoc));
            myModelView = ((ModelView)(swDoc.ActiveView));
            myModelView.FrameState = ((int)(swWindowState_e.swWindowMaximized));
            boolstatus = swDoc.Extension.SelectByID2("Top Plane", "PLANE", 0, 0, 0, false, 0, null, 0);
            swDoc.SketchManager.InsertSketch(true);
            swDoc.ClearSelection2(true);
            skSegment = ((SketchSegment)(swDoc.SketchManager.CreateCircle(0, 0, 0, 0.025635, 0.001202, 0)));
            swDoc.ClearSelection2(true);
            swDoc.SketchManager.InsertSketch(true);
            // 
            // Named View
            swDoc.ShowNamedView2("*Trimetric", 8);
            swDoc.ViewZoomtofit2();
            myFeature = ((Feature)(swDoc.FeatureManager.FeatureExtrusion2(true, false, false, 0, 0, 0.05, 0.01, false, false, false, false, 0.26179938779915, 0.26179938779915, false, false, false, false, true, true, true, 0, 0, false)));
            swDoc.ISelectionManager.EnableContourSelection = false;
            boolstatus = swDoc.EditRebuild3();
            swDoc.ClearSelection2(true);
            boolstatus = swDoc.EditRebuild3();
        }

        /// <summary>
        ///  The SldWorks swApp variable is pre-assigned for you.
        /// </summary>
        public SldWorks swApp;
    }
}


