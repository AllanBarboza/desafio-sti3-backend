using System;
using System.ComponentModel.DataAnnotations;
using AgendaTelefonica.Assets;

public class NotEmptyAttribute : ValidationAttribute
{
    public const string DefaultErrorMessage = Messages.FILD_NOT_BE_EMPTY;
    public NotEmptyAttribute() : base(DefaultErrorMessage) { }

    public override bool IsValid(object value)
    {
        if (value is null)
            return true;

        switch (value)
        {
            case Guid guid:
                return guid != Guid.Empty;
            default:
                return true;
        }
    }
}