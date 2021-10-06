---
# Page settings
layout: page
keywords: Linq Dotnet
---

# Documentation

## Examples

### Select

```cs
// Old Way
var agents = Matrix.GetAgents();
var locations = agents
                    .Select(agent => agent.Location)
                    .ToList();

// Faslinq Way
var agents = Matrix.GetAgentsList();
var locations = agents
                    .Select(
                        agent => agent.Location);
```

### Where

```cs
// Old Way
var agents = Matrix.GetAgents();
var smiths = agents
                    .Where(agent => agent.Name == "Smith")
                    .ToList();

// Faslinq Way
var agents = Matrix.GetAgentsList();
var smiths = agents
                    .Where(
                        agent => agent.Name == "Smith");
```

### Take / TakeLast

```cs
// Old Way
var agents = Matrix.GetRankedAgents();
var bestSquad = agents.Take(3).ToList();
var worstSquad = agents.TakeLast(3).ToList();

// Note - Faslinq Polyfills TakeLast for .Net Framework!

// Faslinq Way
var agents = Matrix.GetRankedAgentsList();
var bestSquad = agents.Take(3);
var worstSquad = agents.TakeLast(3);
```

### Chaining

#### WhereSelect

```cs
// Old Way
var agents = Matrix.GetAgents();
var locations = agents
                    .Where(agent => agent.Name == "Smith")
                    .Select(agent => agent.Location)
                    .ToList();

// Faslinq Way
var agents = Matrix.GetAgentsList();
var locations = agents
                    .WhereSelect(
                        agent => agent.Name == "Smith",
                        agent => agent.Location);
```

#### SelectTake

```cs
// Old Way
var agents = Matrix.GetAgents();
var locations = agents
                    .Select(agent => agent.Location)
                    .Take(3)
                    .ToList();

// Faslinq Way
var agents = Matrix.GetAgentsList();
var locations = agents
                    .SelectTake(
                        agent => agent.Location,
                        3);
```

## Scalar Values

### First / FirstOrDefault / Last / LastOrDefault

```cs
// Old Way
var agents = Matrix.GetAgents();
var _ = agents.FirstOrDefault(agent => agent.CanBeatNeo);
// Discard default value...

// Faslinq Way
var agents = Matrix.GetAgentsList();
var sacrificialLamb = agents.FirstOrDefault
                        agent => agent.CanBeatNeo,
                        agents.Last());
// Polyfill .Net 6 Default Behavior to all targets.
```
