using UnityEngine;

namespace VHSTapeDemo
{
    public class ExampleTapeController : MonoBehaviour
    {
        [SerializeField] private Animator[] animators;

        public void ToggleTopLid(bool open)
        {
            foreach (var animator in animators)
            {
                animator.SetBool("OpenTopLid", open);
            }
        }
    
        public void ReelForward()
        {
            foreach (var animator in animators)
            {
                animator.SetTrigger("ReelForward");
            }
        }
    
        public void ReelBackward()
        {
            foreach (var animator in animators)
            {
                animator.SetTrigger("ReelBackward");
            }
        }
    }
}

