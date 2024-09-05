// Create Philosopher class
using System.Runtime.CompilerServices;

var quote1 = new Quote("I am a smartBoi", Guid.NewGuid(), [PhilosophicalThemes.Phenomenology, PhilosophicalThemes.Logic]);
var quoteFileHandler = new QuoteFileHandler();
var filePath = @"C:\Users\admin\Projects\PhilosophicalQuoteAnalyser\file.txt";
quoteFileHandler.SaveToFile([quote1], filePath);


public class Philosopher(string name, string era)
{
  public string Name { get; init; } = name;
  public Guid Id { get; set; } = Guid.NewGuid();
  public string Era { get; set; } = era;
}

// Create Quote class
public class Quote
{
  public Quote(string text, Guid philosopher, IEnumerable<PhilosophicalThemes> themes)
  {
    Text = text;
    PhilosopherId = philosopher;
    Themes = themes;
  }
  public string Text { get; init; }
  public Guid Id { get; set; } = Guid.NewGuid();
  public Guid PhilosopherId { get; init; }
  public IEnumerable<PhilosophicalThemes> Themes { get; init; }
}

public enum PhilosophicalThemes
{
  Existentialism,
  Absurdism,
  Phenomenology,
  Epistemology,
  Logic,
  Ethics,
  Stoicism,
  Metaphysics,
  Objectivism,
  Aesthetics,
  Poltical
}

// Create repository interface
public interface IRepository<T, T2> where T : class
{
  public void Create(T entity);
  public T Read(T entity);
  public void Update(T entity, T2 data);
  public void Delete(T entity);
}

// Implement Philosopher repository
public class PhilosopherRepository : IRepository<Philosopher, string>
{
  private readonly Dictionary<Guid, Philosopher> _philosophers;

  public PhilosopherRepository()
  {
    _philosophers = new Dictionary<Guid, Philosopher>();
  }

  public void Create(Philosopher entity)
  {
    if (entity.Id == Guid.Empty) entity.Id = Guid.NewGuid();
    _philosophers[entity.Id] = entity;
  }

  public Philosopher Read(Philosopher entity)
  {
    if (_philosophers.ContainsKey(entity.Id)) return _philosophers[entity.Id];
    else throw new KeyNotFoundException($"The philosopher with key '{entity.Id}' cannot be found.");
  }

  public void Update(Philosopher entity, string era)
  {
    _philosophers[entity.Id].Era = era;
  }

  public void Delete(Philosopher entity)
  {
    if (_philosophers.ContainsKey(entity.Id)) _philosophers.Remove(entity.Id);
    else throw new KeyNotFoundException($"{entity.Name} not found.");
  }
}

// Implement Quote repository
public class QuoteRepository : IRepository<Quote, string>
{
  private Dictionary<Guid, Quote> _quotes;

  public QuoteRepository()
  {
    _quotes = new Dictionary<Guid, Quote>();
  }

  public void Create(Quote entity)
  {
    if (entity.Id == Guid.Empty) entity.Id = Guid.NewGuid();
    _quotes[entity.Id] = entity;
  }

  public Quote Read(Quote entity)
  {
    if (_quotes.ContainsKey(entity.Id)) return _quotes[entity.Id];
    else throw new KeyNotFoundException($"The philosopher with key '{entity.Id}' cannot be found.");
  }

  public void Update(Quote entity, string data)
  {
    throw new NotImplementedException();
  }

  public void Delete(Quote entity)
  {
    throw new NotImplementedException();
  }
}

// Create QuoteService interface (retrieve quotes based on criteria)


// Implement QuoteService interface


// Create Filehandler interface
public interface IFilerHandler<T> where T : class
{
  public void SaveToFile(IEnumerable<T> values, string filePath);
  public IEnumerable<T> LoadFromFile(string filePath);
}

// Implement Quote Filehandler
public class QuoteFileHandler : IFilerHandler<Quote>
{
  public IEnumerable<Quote> LoadFromFile(string filePath)
  {
    throw new NotImplementedException();
    // if (!File.Exists(filePath)) throw new FileNotFoundException($"No file can be found using filepath {filePath}.");
    // var quotesLoadedFromFile = File.ReadAllLines(filePath);

  }

  public void SaveToFile(IEnumerable<Quote> values, string filePath)
  {
    IEnumerable<string> toWriteToFileArr;
    string toWriteToFile;
    foreach (var value in values)
    {
      System.Console.WriteLine("Value: " + value.Id.ToString());
      System.Console.WriteLine("Value: " + value.PhilosopherId.ToString());
      System.Console.WriteLine("Value: " + value.Text);
      System.Console.WriteLine("Value: " + value.Themes.ToString());
      toWriteToFileArr = QuoteToIEnumerable(value);
      toWriteToFile = string.Join(',', toWriteToFileArr);
      File.AppendAllText(filePath, toWriteToFile);
    }
  }

  private IEnumerable<string> QuoteToIEnumerable(Quote quote)
  {
    var result = new List<string>();
    result.Add(quote.Id.ToString());
    result.Add(quote.PhilosopherId.ToString());
    result.Add(quote.Text.ToString());
    quote.Themes.ToList().ForEach(x => result.Add(x.ToString()));
    return result;
  }

  private IEnumerable<Quote> IEnumerableToQuote(IEnumerable<string> strings)
  {
    throw new NotImplementedException();
    // foreach (var)
    // var result = new Quote();

  }
}

// Implement Philosopher Filehandler


