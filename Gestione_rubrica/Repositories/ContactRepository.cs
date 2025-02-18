using Gestione_rubrica.Models;

namespace Gestione_rubrica.Repositories;

/// <summary>
/// Provides a repository for managing contacts.
/// Implements functionality to add, remove, search, and retrieve all contacts.
/// </summary>
public class ContactRepository : IContactRepository
{
    /// <summary>
    /// A private field that holds a collection of contacts.
    /// Represents a list of Contact objects managed within the repository.
    /// </summary>
    private readonly List<Contact> _contacts;

    /// <summary>
    /// A repository class for managing contact information in a list.
    /// Provides functionality to add, remove, find, and retrieve all contacts.
    /// Implements the <see cref="IContactRepository"/> interface.
    /// </summary>
    public ContactRepository()
    {
        _contacts = new List<Contact>();
    }

    /// <summary>
    /// Adds a new contact to the repository.
    /// </summary>
    /// <param name="contact">The contact to add. This includes details like first name, last name, phone number, and email.</param>
    public void AddContact(Contact contact)
    {
        _contacts.Add(contact);
    }

    /// <summary>
    /// Removes a contact based on the provided phone number.
    /// If a contact with the specified phone number exists, it is removed from the repository.
    /// </summary>
    /// <param name="phoneNumber">The phone number of the contact to remove.</param>
    /// <returns>
    /// Returns <c>true</c> if a contact was successfully removed; otherwise, <c>false</c>.
    /// </returns>
    public bool RemoveContact(string phoneNumber)
    {
        var contactRemove = _contacts.FirstOrDefault(c => c.PhoneNumber == phoneNumber);
        if (contactRemove != null)
        {
            _contacts.Remove(contactRemove);
            return true;
        }

        return false;
    }

    /// <summary>
    /// Finds and retrieves a contact by their phone number.
    /// </summary>
    /// <param name="phoneNumber">The phone number of the contact to be retrieved.</param>
    /// <returns>
    /// The contact associated with the specified phone number, or null if no such contact exists.
    /// </returns>
    public Contact FindContactByPhone(string phoneNumber)
    {
        return _contacts.FirstOrDefault(c => c.PhoneNumber == phoneNumber);
    }

    /// <summary>
    /// Retrieves all contacts stored in the repository.
    /// </summary>
    /// <returns>
    /// A list of all contact objects.
    /// </returns>
    public List<Contact> GetAllContacts()
    {
        return _contacts.ToList();
    }
}