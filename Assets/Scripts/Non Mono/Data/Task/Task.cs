public class Task
{
    public TaskType taskType;
    public bool isFree;

    public Task(TaskType taskType)
    {
        this.taskType = taskType;
        isFree = true;
    }
}