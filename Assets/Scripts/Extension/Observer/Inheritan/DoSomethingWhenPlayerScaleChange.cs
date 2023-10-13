namespace Extension.Observer
{
    public class DoSomethingWhenPlayerScaleChange : Observer
    {
        public override void DoSomething()
        {
            Destroy(gameObject);
        }
    }
}