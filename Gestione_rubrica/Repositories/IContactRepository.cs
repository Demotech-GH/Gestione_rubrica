using Gestione_rubrica.Models;

namespace Gestione_rubrica.Repositories;

/// <summary>
/// Interface for managing contact operations in a repository.
/// Provides methods to add, remove, find, and retrieve all contacts.
/// </summary>
public interface IContactRepository
{
    /// <summary>
    /// Adds a new contact to the contact repository.
    /// </summary>
    /// <param name="contact">The contact object containing details such as first name, last name, phone number, and email to be added.</param>
    void AddContact(Contact contact);

    /// <summary>
    /// Removes a contact from the repository using the specified phone number.
    /// </summary>
    /// <param name="phoneNumber">The phone number of the contact to be removed.</param>
    /// <returns>
    /// A boolean value indicating whether the removal was successful.
    /// Returns true if the contact was removed successfully; otherwise, false.
    /// </returns>
    bool RemoveContact(string phoneNumber);

    /// <summary>
    /// Finds and returns a contact based on the provided phone number.
    /// </summary>
    /// <param name="phoneNumber">The phone number of the contact to search for.</param>
    /// <returns>A <see cref="Contact"/> object if a contact with the specified phone number is found; otherwise, null.</returns>
    Contact FindContactByPhone(string phoneNumber);

    /// <summary>
    /// Retrieves all contacts stored in the repository.
    /// </summary>
    /// <returns>A list containing all contact objects.</returns>
    List<Contact> GetAllContacts();

}