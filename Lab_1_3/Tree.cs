public class Tree
{
    public List<Tree> Child { get; set; }
    public string Value { get; set; }
    public Tree(string value)
    {
        Value = value;
        Child = new List<Tree>();
    }
    public void NewChild(Tree node)
    {
        Child.Add(node);
    }
    public void ShowTree(string[] myarray, ref int id)
    {
        if (Child.Count > 0)
        {
            myarray[id++] = "Потомки узла " + Value + ": ";
            for (int i = 0; i < Child.Count; i++)
            {
                myarray[id++] = Child[i].Value;
            }
            for (int i = 0; i < Child.Count; i++)
            {
                Child[i].ShowTree(myarray, ref id);
            }
        }
    }
}