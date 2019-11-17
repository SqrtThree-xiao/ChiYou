using NodeCanvas.Framework;


namespace NodeCanvas.DialogueTrees
{

    public class DTConnection : Framework.Connection
    {

        ///----------------------------------------------------------------------------------------------
        ///---------------------------------------UNITY EDITOR-------------------------------------------
#if UNITY_EDITOR

        public override ParadoxNotion.PlanarDirection direction {
            get { return ParadoxNotion.PlanarDirection.Vertical; }
        }

#endif
        ///----------------------------------------------------------------------------------------------

    }
}