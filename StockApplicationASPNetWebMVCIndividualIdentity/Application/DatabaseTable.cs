using System.ComponentModel.DataAnnotations;

namespace StockApplicationASPNetWebMVCIndividualIdentity.Application;

public abstract class DatabaseTable
{
    private long _id = 1;

    [Key]
    public virtual long Id
    {
        get => _id;
        set
        {
            _id = value;
            _id = Id;
        }
    }

}