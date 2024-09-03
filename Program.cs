// Create Philosopher class
using System.Runtime.CompilerServices;

public class Philosopher(string name, Guid id, string era)
{
  public string Name { get; init; } = name;
  public Guid Id { get; init; } = id;
  public string Era { get; init; } = era;
  public
}

// Create Quote class
public class Quote(string text, Guid id, Guid philosopherId, IEnumerable<PhilosophicalThemes> themes)
{
  public string Text { get; init; } = text;
  public Guid Id { get; init; } = id;
  public Guid PhilosopherId { get; init; } = philosopherId;
  public IEnumerable<PhilosophicalThemes> Themes { get; init; } = themes;
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
public interface IRepository<T> where T : class
{
  public void Create(T entity);
  public void Read(T entity);
  public void Update(T entity);
  public void Delete(T entity);
}

// Implement Philosopher repository
public class PhilosopherRepository : IRepository<Philosopher>
{
  public void Create(Philosopher entity)
  {
    throw new NotImplementedException();
  }

  public void Delete(Philosopher entity)
  {
    throw new NotImplementedException();
  }

  public void Read(Philosopher entity)
  {
    throw new NotImplementedException();
  }

  public void Update(Philosopher entity)
  {
    throw new NotImplementedException();
  }
}

// Implement Quote repository
public class QuoteRepository : IRepository<Quote>
{
  public void Create(Quote entity)
  {
    throw new NotImplementedException();
  }

  public void Delete(Quote entity)
  {
    throw new NotImplementedException();
  }

  public void Read(Quote entity)
  {
    throw new NotImplementedException();
  }

  public void Update(Quote entity)
  {
    throw new NotImplementedException();
  }
}

// Create QuoteService interface (retrieve quotes based on criteria)


// Implement QuoteService interface


// Create Filehandler interface


// Implement Quote Filehandler


// Implement Philosopher Filehandler


