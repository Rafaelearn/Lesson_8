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
            DoHomeTask1();
        }
        static void DoTask()
        {
            Account account1 = new Account(TypeAccount.accountCurrent, 100);
            Account account2 = new Account(TypeAccount.accountSavings, 350);
            account1.PutMoneyFromAccount(ref account2, 100);
            account1.PutMoney(100);
            account1.Withdraw(75);
            account1.Dispose();
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
