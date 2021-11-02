using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    class Program
    {
        static void Main(string[] args)
        {
            DoTask();
            //DoHomeTask1();
        }
        static void DoTask()
        {
            Account account1 = new Account(TypeAccount.accountCurrent, 100);
            Account account2 = new Account(TypeAccount.accountSavings, 200);
            account2.PutMoneyFromAccount(ref account1, 50);
            account1.PutMoney(100);
            account2.Withdraw(75);
        }
        static void DoHomeTask1()
        {
            //Test ctor
            Song song1 = new Song();
            Song song2 = new Song("Хабиб", "Ягода малинка");
            Song song3 = new Song("Клава Кока", "Пьяную домой", song2);
            song1.Dispay();
            song2.Dispay();
            song3.Dispay();
        }

    }
}
