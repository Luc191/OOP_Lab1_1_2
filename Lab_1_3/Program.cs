string[] myarray = new string[20];
int id = 0;

Tree begin = new Tree("Животные");
Tree node1 = new Tree("Бесчерепные");
Tree node2 = new Tree("Оболочники");
Tree node3 = new Tree("Позвоночные");
Tree node4 = new Tree("Ланцетники");
Tree node5 = new Tree("Аппендикулярии");
Tree node6 = new Tree("Асцидии");
Tree node7 = new Tree("Сальпы");
Tree node8 = new Tree("Бореоэутерии");
Tree node9 = new Tree("Эуархонтоглиры");
Tree node10 = new Tree("Лавразиатерии");

begin.NewChild(node1);
begin.NewChild(node2);
begin.NewChild(node3);
node1.NewChild(node4);
node2.NewChild(node5);
node2.NewChild(node6);
node2.NewChild(node7);
node3.NewChild(node8);
node8.NewChild(node9);
node8.NewChild(node10);

begin.ShowTree(myarray, ref id);

for (int i = 0; i < id; i++)
{
    Console.WriteLine(myarray[i]);
}


