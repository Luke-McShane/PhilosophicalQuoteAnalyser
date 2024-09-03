// Create Philosopher class
using System.Runtime.CompilerServices;

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
  public required string Text { get; init; }
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

  public void Delete(Philosopher entity)
  {
    if (_philosophers.ContainsKey(entity.Id)) _philosophers.Remove(entity.Id);
    else throw new KeyNotFoundException($"{entity.Name} not found.");
  }

  public Philosopher Read(Philosopher entity)
  {
    if (_philosophers.ContainsKey(entity.Id)) return _philosophers[entity.Id];
    else throw new KeyNotFoundException($"The key '{entity.Id}' cannot be found.");
  }

  public void Update(Philosopher entity, string era)
  {
    _philosophers[entity.Id].Era = era;
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
    throw new NotImplementedException();
  }

  public Quote Read(Quote entity)
  {
    throw new NotImplementedException();
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


// Implement Quote Filehandler


// Implement Philosopher Filehandler


