namespace Robolab.Story.Behaviour
{
    using Robolab.Wwise.Events;
    using UnityEngine;

    public class Story_VO : StoryBehaviourBase
    {
        [SerializeField] private string _VOEventID = default;

        [SerializeField] private bool _StopOnExit = true;

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            base.OnStateEnter(animator, stateInfo, layerIndex);

            // Post VO event
            WwiseEventHelper.PlayVO(_VOEventID, _storyGameObjectReferences.NPC);
        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            base.OnStateExit(animator, stateInfo, layerIndex);

            // Force stop VO
            if (_StopOnExit)
            {
                WwiseEventHelper.StopEventID(WwiseEventIDs.RADIO_ON);
                WwiseEventHelper.StopEventID(WwiseEventIDs.RADIO_STATIC);
                WwiseEventHelper.StopEventID(_VOEventID);
                WwiseEventHelper.StopEventID(WwiseEventIDs.RADIO_OFF);
            }
        }
    }
}
