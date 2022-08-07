namespace Robolab.Story.Behaviour
{
    using UnityEngine;

    public class StoryBehaviourBase : StateMachineBehaviour
    {
        private const string STORY_STATE_INDEX_PARAMETER = "Story_State_Index";

        [SerializeField] private float _stayInStateForSeconds = 2f;
        [SerializeField] private int _storyStateIndexToTransitionTo = -1;

        protected StoryGameObjectReferences _storyGameObjectReferences = null;

        private float _timeInState = 0f;
        private int _storyStateIndexParameterHash = Animator.StringToHash(STORY_STATE_INDEX_PARAMETER);

        public override void OnStateMachineEnter(Animator animator, int stateMachinePathHash)
        {
            // Init
            Init(animator);
        }

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            // Init
            Init(animator);
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            // Switch states once the time in state has expired
            if (_timeInState <= 0f)
            {
                animator.SetInteger(_storyStateIndexParameterHash, _storyStateIndexToTransitionTo);
            }
            else
            {
                _timeInState -= Time.deltaTime;
            }
        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) { }

        public override void OnStateMachineExit(Animator animator, int stateMachinePathHash) { }

        private void Init(Animator animator)
        {
            // Init references to story objects
            if (_storyGameObjectReferences == null)
            {
                _storyGameObjectReferences = animator.gameObject.GetComponent<StoryGameObjectReferences>();
            }

            // Init time in state variable
            _timeInState = _stayInStateForSeconds;
        }
    }
}