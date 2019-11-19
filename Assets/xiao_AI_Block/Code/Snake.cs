using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace xiao_Demo01
{
    public class Snake : MonoBehaviour//, IEnumerable
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
        public static KeyCode Listener_keyboard()
        {
            KeyCode keyCode = 0;

            if (EventType.KeyDown == Event.current.type)
            {
                keyCode = Event.current.keyCode;
            }

            return keyCode;
        }

        //IEnumerator IEnumerable.GetEnumerator()
        //{
        //    throw new System.NotImplementedException();
        //}
    }
}


