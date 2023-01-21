using Microsoft.EntityFrameworkCore;
using Moq;
using NuGet.Packaging;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.FinancialStatements.KeyMetrics;
using StockApplicationASPNetWebMVCIndividualIdentity.Application.Repository;

namespace StockApplication.Core.Tests.Application;

public class KeyMetricsServiceTests
{
    private List<KeyMetricsDto> _data;
    private Mock<DbSet<KeyMetricsDto>> _mockSet;
    private Mock<StockContext> _context;

    public KeyMetricsServiceTests()
    {
        // Data
        _data = new List<KeyMetricsDto>
        {
            new() { Id = 1, Symbol = "", Period = "", Date = DateTimeOffset.Now, },
            new() { Id = 2, Symbol = "", Period = "", Date = DateTimeOffset.Now,  },
            new() { Id = 3, Symbol = "", Period = "", Date = DateTimeOffset.Now,  },
        };
        
        //Setup DbSetMock
        _mockSet = new Mock<DbSet<KeyMetricsDto>>();
        _mockSet.As<IQueryable<KeyMetricsDto>>().Setup(m => m.Provider).Returns(_data.AsQueryable().Provider);
        _mockSet.As<IQueryable<KeyMetricsDto>>().Setup(m => m.Expression).Returns(_data.AsQueryable().Expression);
        _mockSet.As<IQueryable<KeyMetricsDto>>().Setup(m => m.ElementType).Returns(_data.AsQueryable().ElementType);
        _mockSet.As<IQueryable<KeyMetricsDto>>().Setup(m => m.GetEnumerator()).Returns(() => _data.AsQueryable().GetEnumerator());
        _mockSet.Setup(d => 
                d.Add(It.IsAny<KeyMetricsDto>()))
            .Callback<KeyMetricsDto>((s) => _data.Add(s));
        _mockSet.Setup(d => 
                d.AddRange(It.IsAny<IEnumerable<KeyMetricsDto>>()))
            .Callback<IEnumerable<KeyMetricsDto>>((s) => _data.AddRange(s));
        
        //Setup Context
        _context = new Mock<StockContext>();
        _context.Setup(x => x.KeyMetrics).Returns(_mockSet.Object);

    }
    
    [Fact]
    public void KeyMetricsServiceAddToMetricsSavesRange()
    {
        var service = new KeyMetricsService(new KeyMetricsRepository(_context.Object));
        service.AddToKeyMetrics(new List<KeyMetricsDto>()
        {
            new() { Id = 4, Symbol = "", Period = "", Date = DateTimeOffset.Now,  }
        });

        Assert.Equal(4, _mockSet.Object.Count());
        Assert.Equal(4, _mockSet.Object.Last().Id); 
    }
}
