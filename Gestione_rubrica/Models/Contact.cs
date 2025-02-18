namespace Gestione_rubrica.Models;

/// <summary>
/// Represents a contact with personal details such as first name,
/// last name, phone number, and email address.
/// </summary>
public class Contact
{
    /// <summary>
    /// Gets or sets the first name of the contact.
    /// </summary>
    public string FirstName { get; set; }

    /// <summary>
    /// Gets or sets the last name of the contact.
    /// </summary>
    public string LastName { get; set; }

    /// <summary>
    /// Gets or sets the phone number for the contact.
    /// </summary>
    /// <remarks>
    /// The phone number is a string representation of the contact's telephone number.
    /// This property is used as a unique identifier in methods such as finding or removing contacts from a repository.
    /// </remarks>
    public string PhoneNumber { get; set; }

    /// <summary>
    /// Represents the email address associated with the contact.
    /// </summary>
    public string Email { get; set; }

    /// Represents a contact with personal details such as first name, last name, phone number, and email.
    public Contact(string firstName, string lastName, string phoneNumber, string email)
    {
        FirstName = firstName;
        LastName = lastName;
        PhoneNumber = phoneNumber;
        Email = email;
    }


    /// Returns a string representation of the contact, including first name, last name,
    /// phone number, and email in a formatted manner.
    /// <returns>A string containing the contact's full name, phone number, and email.</returns>
    public override string ToString()
    {
        return $"{FirstName} {LastName} | Tel : {PhoneNumber} | Email : {Email} ";
    }
    
    
    
}