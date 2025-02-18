using Gestione_rubrica.Models;
using Gestione_rubrica.Repositories;

namespace Gestione_rubrica
{
    /// <summary>
    /// The <c>Program</c> class serves as the main entry point for the application.
    /// It belongs to the <c>Gestione_rubrica</c> namespace.
    /// </summary>
    /// <remarks>
    /// This class is internal to the assembly and is primarily used to initialize and execute the application logic.
    /// </remarks>
    internal class Program
    {
        /// <summary>
        /// The entry point of the application.
        /// Initializes the contact repository and handles the primary menu-driven flow for managing contacts.
        /// </summary>
        /// <remarks>
        /// This method provides a console-based interface for managing a contact directory.
        /// Users can add, remove, find, and list contacts through a series of menu options.
        /// The application will continue running until the user chooses to exit.
        /// </remarks>
        static void Main()
        {
            IContactRepository contactRepo = new ContactRepository();
            
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\n--- Rubrica ---");
                Console.WriteLine("1) Aggiungi contatto");
                Console.WriteLine("2) Rimuovi contatto");
                Console.WriteLine("3) Trova contatto(per numero di telefono)");
                Console.WriteLine("4) Visualizza tutti i contatti");
                Console.WriteLine("5) Esci");
                Console.WriteLine("Seleziona una opzione ");
                
                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddContactFlow(contactRepo);
                        break;
                    case "2":
                        RemoveContactFlow(contactRepo);
                        break;
                    case "3":
                        FindContactFlow(contactRepo);
                        break;
                    case "4":
                        ListAllContactFlow(contactRepo);
                        break;
                    case "5":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Opzione non valida");
                        break;
                    
                }
                
            }
            
        }

        /// <summary>
        /// Handles the process of searching for a contact by phone number.
        /// Prompts the user for a phone number, searches the repository,
        /// and displays the result of the search.
        /// </summary>
        /// <param name="contactRepo">The contact repository to search in.</param>
        private static void FindContactFlow(IContactRepository contactRepo)
        {
            Console.WriteLine("Inserisci il numero di telefono da cercare: ");
            string phoneNumber = Console.ReadLine() ?? string.Empty;
            
            var found = contactRepo.FindContactByPhone(phoneNumber);
            
            if (found != null)
            {
                Console.WriteLine("Contatto trovato : " + found);
            }
            else
            {
                Console.WriteLine("Contatto non trovato");
            }
        }

        /// <summary>
        /// Handles the flow for removing a contact from the repository.
        /// Prompts the user to enter a phone number and attempts to remove the corresponding contact.
        /// Provides feedback on whether the removal was successful or not.
        /// </summary>
        /// <param name="contactRepo">The contact repository used to perform the removal operation.</param>
        private static void RemoveContactFlow(IContactRepository contactRepo)
        {
        
            Console.WriteLine("Inserisci il numero di telefono da rimuovere: ");
            string phoneNumber = Console.ReadLine() ?? string.Empty;
            
            bool succes = contactRepo.RemoveContact(phoneNumber);
            
            if (succes)
            {
                Console.WriteLine("Contatto rimosso");
            }
            else
            {
                Console.WriteLine("Contatto non trovato");
            }
            
        }


        /// <summary>
        /// Handles the process of adding a new contact by collecting user input for contact details
        /// and storing the new contact into the repository.
        /// </summary>
        /// <param name="contactRepo">The repository interface used to add the new contact.</param>
        private static void AddContactFlow(IContactRepository contactRepo)
        {
            Console.WriteLine("Inserisci il nome: ");
            string firstName = Console.ReadLine() ?? string.Empty;
            
            Console.WriteLine("Inserisci il cognome: ");
            string lastName = Console.ReadLine() ?? string.Empty;
            
            Console.WriteLine("Inserisci il numero di telefono: ");
            string phoneNumber = Console.ReadLine() ?? string.Empty;
            
            Console.WriteLine("Inserisci l'email: ");
            string email = Console.ReadLine() ?? string.Empty;
            
            var newContact = new Contact(firstName, lastName, phoneNumber, email);
            contactRepo.AddContact(newContact);
            
            Console.WriteLine("Contatto aggiunto");
            
        }


        /// <summary>
        /// Lists all contacts stored in the contact repository.
        /// If no contacts are present, a message indicating an empty repository is displayed.
        /// </summary>
        /// <param name="contactRepo">The contact repository used to retrieve the list of contacts.</param>
        private static void ListAllContactFlow(IContactRepository contactRepo)
        {
            
            var contacts = contactRepo.GetAllContacts();

            if (contacts.Count == 0)
            {
                Console.WriteLine("La rubrica è vuota");
            }
            else
            {
                Console.WriteLine("Contatti:");

                foreach (var c in contacts)
                {
                    Console.WriteLine(c);
                }
                
            }
            
        }
        
    }
}