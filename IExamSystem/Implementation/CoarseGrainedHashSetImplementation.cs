namespace IExamSystem.Implementation;

using IExamSystem.Collections;

public class CoarseGrainedExamSystem : Interface.IExamSystem
{
    private readonly CoarseGrainedHashSet<Tuple<long, long>> _store;

    public CoarseGrainedExamSystem()
    {
        _store = new CoarseGrainedHashSet<Tuple<long, long>>(20);
    }

    public CoarseGrainedExamSystem(int capacity)
    {
        _store = new CoarseGrainedHashSet<Tuple<long, long>>(capacity);
    }

    public int Count => _store.Count();
    public void Add(long studentId, long courseId) => _store.Add(new(studentId, courseId));
    public bool Contains(long studentId, long courseId) => _store.Contains(new(studentId, courseId));
    public void Remove(long studentId, long courseId) => _store.Remove(new(studentId, courseId));
}