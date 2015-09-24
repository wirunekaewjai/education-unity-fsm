
namespace Devdayo.FSM.Core
{
    internal sealed class Instance : Singleton<Instance>
    {
        private MethodCreator method;

        private StateCreator creator;
        private StateChanger changer;
        private StateUpdater updater;
        private StateDestroyer destroyer;

        private Invoker invoker;

        private bool destroyed;
        
        private void Awake()
        {
            // print("Awake");

            destroyer = new StateDestroyer();

            method = new MethodCreator();

            creator = new StateCreator(this);
            creator.Start();

            changer = new StateChanger();
            updater = new StateUpdater();

            invoker = new Invoker();

            StartCoroutine(invoker.Update());

            destroyed = false;
        }
        
        private void Update()
        {
            if (destroyed)
                return;

            // print("Update");
            updater.Update();
        }
        

        private void FixedUpdate()
        {
            if (destroyed)
                return;

            changer.FixedUpdate();
            updater.FixedUpdate();
        }

        private void LateUpdate()
        {
            if (destroyed)
                return;

            updater.LateUpdate();
        }

        private void OnDestroy()
        {
            if (destroyed)
                return;

            // print("Destroy");
            destroyed = true;

            StopAllCoroutines();
            invoker.Destroy();

            destroyer.Destroy();

            method.Destroy();
            creator.Destroy();
            changer.Destroy();
            // updater.Destroy();
        }

        private void OnApplicationQuit()
        {
            if (!destroyed)
                OnDestroy();

            // print("Quit");

            invoker = null;
            destroyer = null;
            method = null;
            creator = null;
            changer = null;
            updater = null;
        }

        public static MethodCreator Method
        {
            get { return Instance.method; }
        }

        public static StateCreator Creator
        {
            get { return Instance.creator; }
        }

        public static StateChanger Changer
        {
            get { return Instance.changer; }
        }
        
        public static StateUpdater Updater
        {
            get { return Instance.updater; }
        }

        public static StateDestroyer Destroyer
        {
            get { return Instance.destroyer; }
        }

        public static Invoker Invoker
        {
            get { return Instance.invoker; }
        }
    }
}
