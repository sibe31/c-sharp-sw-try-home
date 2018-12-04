
//KEEP THESE LINES OF CODE
using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;
using System;
namespace CreateCutExtrudeCSharp.csproj
{
    public partial class SolidWorksMacro
    {
        public void Main()
        {
            ModelDoc2 swDoc = null;
            //COMMENT OUT THIS LINE OF CODE
            //bool boolstatus = false;
            //KEEP THIS LINE OF CODE
            swDoc = ((ModelDoc2)(swApp.ActiveDoc));

            //ADD THESE LINES OF CODE
            double holeRadius;
            double holeDepth;
            //Create an instance of the user form
            frmCutExtrude myForm = new frmCutExtrude();

            //Set the title for the form
            myForm.Text = "Size of Cut-Extrude in Millimeters";
            //Display the user form and retrieve radius and 
            //depth values typed by the user; divide those values
            //by 1000 to change millimeters to meters
            myForm.ShowDialog();
            holeRadius = myForm.radius / 1000;
            holeDepth = myForm.depth / 1000;
            //Dispose of the user form and remove it from
            //memory because it's no longer needed
            myForm.Dispose();


            //COMMENT OUT THIS LINE OF CODE
            //boolstatus = swDoc.Extension.SelectByID2("", "FACE", 
            //-0.002217633926534, 0.2200000000001, 0.008129330308691, 
            //false, 0, null, 0); 
            //ADD THESE LINES OF CODE 
            //Get coordinates of selection point
            SelectionMgr swSelectionMgr = null;
            swSelectionMgr = (SelectionMgr)swDoc.SelectionManager;
            double[] SelectCoordinates;
            SelectCoordinates = (double[])swSelectionMgr.GetSelectionPoint2(1, -1);
            //If face is selected, then open a sketch;
            //otherwise, stop execution
            object SelectedObject = null;
            SelectedObject = (object)swSelectionMgr.GetSelectedObject6(1, 0);
            int objtype;
            objtype = (int)swSelectionMgr.GetSelectedObjectType3(1, -1);
            if (objtype == (int)swSelectType_e.swSelFACES)
            {
                swDoc.SketchManager.InsertSketch(true);
                //COMMENT OUT THESE LINES OF CODE
                //swDoc.ClearSelection2(true);
                //SketchSegment skSegment = null;
                //skSegment = ((SketchSegment)(swDoc.SketchManager.CreateCircle(0, 
                //0, 0, 0.008219, -0.012877, 0)));
                //swDoc.ClearSelection2(true);
                //boolstatus = swDoc.Extension.SelectByID2("Arc1", "SKETCHSEGMENT", 
                //0, 0, 0, false, 0, null, 0);
                //Feature myFeature = null;
                //myFeature = ((Feature)(swDoc.FeatureManager.FeatureCut(true, 
                //false, false, 0, 0, 0.025, 0.01, true, false, false, 
                //false, 0.2617993877992, 0.2617993877992, false, false, 
                //false, false, false, true, true)));
                //swDoc.ISelectionManager.EnableContourSelection = false;
                //ADD THESE LINES OF CODE 
                //Get IMathPoint to use when transforming
                //from model space to sketch space
                MathUtility swMathUtility = null;
                MathPoint swMathPoint = null;
                Sketch swSketch = null;
                double dx;
                double dy;
                double dz;
                swMathUtility = (MathUtility)swApp.GetMathUtility();
                swMathPoint = (MathPoint)swMathUtility.CreatePoint(SelectCoordinates);
                //Get reference to sketch
                swSketch = (Sketch)swDoc.SketchManager.ActiveSketch;
                //Translate sketch point into sketch space
                MathTransform swMathTransform = null;
                swMathTransform = (MathTransform)swSketch.ModelToSketchTransform;
                swMathPoint = (MathPoint)swMathPoint.MultiplyTransform(swMathTransform);
                //Retrieve coordinates of the sketch point
                double[] darray;
                darray = (double[])swMathPoint.ArrayData;
                dx = darray[0];
                dy = darray[1];
                dz = darray[2];

                /*
                //Use swDoc.SketchManager.CreateCircleByRadius instead of
                //swDoc.SketchManager.CreateCircle because
                //swDoc.SketchManager.CreateCircleByRadius sketches a
                //circle centered on a sketch point and lets you 
                //specify a radius
                double radius = 0.015;
                SketchSegment swSketchSegment = null;
                swSketchSegment = (SketchSegment)swDoc.SketchManager.CreateCircleByRadius(dx, dy, dz, radius);
                //Create the cut extrude feature
                Feature swFeature = null;
                swFeature = (Feature)swDoc.FeatureManager.FeatureCut3(true, false, false, 0, 0, 0.025, 0.01, true, false, false, false, 0, 0, false, false, false, false, false, true, true, false, false, false, (int)swStartConditions_e.swStartSketchPlane, 0, false);
            
                 */ 
                 
            //Create the sketch for cut-extrude
            SketchSegment swSketchSegment = null;
            swSketchSegment = (SketchSegment)swDoc.SketchManager.CreateCircleByRadius(dx, dy, dz, holeRadius);
            //Create the cut-extrude feature
            Feature swFeature = null;
            swFeature = (Feature)swDoc.FeatureManager.FeatureCut3(true, false, false, 0, 0, holeDepth, 0.01, true, false, false, false, 0, 0, false, false, false, false, false, true, true, false, false, false, (int)swStartConditions_e.swStartSketchPlane, 0, false);

}
}
//KEEP THESE LINES OF CODE
///<summary>
///The Sldworks swApp variable is pre-assigned for you.
///</summary>
public SldWorks swApp;
}

            
}
                  
               
 