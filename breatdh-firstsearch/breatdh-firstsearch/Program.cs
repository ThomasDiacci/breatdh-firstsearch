
using breatdh_firstsearch;
using System.Linq;

var list = new List<string>();
list.Add("Alice");
list.Add("Bob");
list.Add("Claire");

for (int i = 0; i < list.Count; i++)
{
    if (PersonIsSeller(list[i]))
    {
        Console.WriteLine($"Seller is: {list[i]}");
        break;
    }
    else
    {
        //aggiungere gli amici dell'amico per espendere la ricerca
    }

    if (i + 1 == list.Count)
    {
        Console.WriteLine($"Seller not found");
    }
}

//altro metodo

var graph = new Dictionary<string, string[]>();
graph.Add("you", new string[] { "alice", "bob", "claire" });
graph.Add("bob", new string[] { "anuj", "peggy" });
graph.Add("alice", new string[] { "peggy" });
graph.Add("claire", new string[] { "thom", "jonny" });
graph.Add("anuj", new string[0]);
graph.Add("peggy", new string[0]);
graph.Add("thom", new string[0]);
graph.Add("jonny", new string[0]);

//var arr = new string[100];
//arr = arr.Concat(new string[] { "alice", "bob", "claire" }).ToArray();//.EnqueueDataToArray(new string[] { "alice", "bob", "claire" });

//for (int i = 0; i < arr2.Length; i++)
//{
//    Console.WriteLine(arr2[i]);
//}

SearchQueue(graph["you"]);


bool SearchQueue(string[] dataToSearch)
{
    //ciclo per tutta la lunghezza della coda
    //il ciclo così composto non va bene perché il ridimensionamento dell'array
    //reindirizza gli indici, mentre "i" prosegue nel suo incrementale
    //risultandone un salto di elementi
    //for (int i = 0; i < dataToSearch.Length; i++)
    //{
    //    //prelevo il primo elemento
    //    var person = dataToSearch[i];
    //    //rimuovo l'elemento selezionato
    //    dataToSearch = dataToSearch.Where(x => !x.Equals(person)).ToArray();

    //    //controllo se è un venditore
    //    if (PersonIsSeller(person))
    //    {//allora ho trovato chi può vendere il mango
    //        Console.WriteLine($"Seller is: {person}");

    //        return true;
    //    }
    //    else
    //    {//allora aggiungo i suoi amici alla ricerca
    //        //in questo modo cerco prima negli amici di amici che quelli più stretti
    //        //SearchQueue(graph[person]);
    //        dataToSearch = dataToSearch.Concat(graph[person]).ToArray();
    //    }
    //}

    //ciclo su tutti gli elementi
    //anche così non funziona, perché nonostante si aggiungano elementi all'array originale
    //questi non vengono presi nel ciclo
    //foreach (var item in dataToSearch)
    //{
    //    //prelevo il primo elemento
    //    var person = item;
    //    //rimuovo l'elemento selezionato
    //    dataToSearch = dataToSearch.Where(x => !x.Equals(person)).ToArray();

    //    //controllo se è un venditore
    //    if (PersonIsSeller(person))
    //    {//allora ho trovato chi può vendere il mango
    //        Console.WriteLine($"Seller is: {person}");

    //        return true;
    //    }
    //    else
    //    {//allora aggiungo i suoi amici alla ricerca
    //        //in questo modo cerco prima negli amici di amici che quelli più stretti
    //        //SearchQueue(graph[person]);
    //        dataToSearch = dataToSearch.Concat(graph[person]).ToArray();
    //    }
    //}

    //ciclo finché ho elementi nell'array
    while (dataToSearch != null || dataToSearch.Length > 1)
    {
        //prelevo il primo elemento
        var person = dataToSearch[0];
        //rimuovo l'elemento selezionato
        dataToSearch = dataToSearch.Where(x => !x.Equals(person)).ToArray();

        //controllo se è un venditore
        if (PersonIsSeller(person))
        {//allora ho trovato chi può vendere il mango
            Console.WriteLine($"Seller is: {person}");

            return true;
        }
        else
        {//allora aggiungo i suoi amici alla ricerca
            dataToSearch = dataToSearch.Concat(graph[person]).ToArray();
        }
    }

    //se sono arrivato fino a qua allora nessuno è un venditore
    return false;
}

//ipotizziamo che il venditore sia identificato con la lettera finale "m"
bool PersonIsSeller(string name){
    return name.ToUpper().Last() == 'M';
}