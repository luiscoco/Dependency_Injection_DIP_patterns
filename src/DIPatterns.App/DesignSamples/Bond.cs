using System;

namespace DIPatterns.App.DesignSamples;

interface IRepository
{
    BondData GetBondData();
}

internal class BondData
{
}

class SqlRepository : IRepository
{
    public BondData GetBondData()
    {
        throw new NotImplementedException();
    }
}

// Bad! Bond depends on concrete class SqlRepository
class Bond1
{
    private readonly SqlRepository _repository = new SqlRepository();
    public Bond1()
    {
        var bondData = _repository.GetBondData();
    }
}

// Bad! Bond depends on abstraction IRepository
class Bond2
{
    private readonly IRepository _repository;
    public Bond2(IRepository repository)
    {
        _repository = repository;
        var bondData = _repository.GetBondData();
    }
}

// Good! Bond does not know anything about Data Access Layer
class Bond3
{
    public Bond3(BondData bondData)
    { }
}