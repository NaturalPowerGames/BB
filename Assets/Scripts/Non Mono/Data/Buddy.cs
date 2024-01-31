
[System.Serializable]
public class Buddy
{
	private float[] needs;
	private bool hasHabitatAssigned;

	public float GetNeed(Need need)
	{
		return needs[(int)need];
	}

	public void Initialize(Buddy buddy)
	{
		this.needs = buddy.needs;
	}

	public Buddy(float[] needs)
	{
		this.needs = needs;
	}

	public void DecreaseNeeds(float tickTime)
	{
		for (int i = 0; i < needs.Length; i++)
		{
			needs[i] -= tickTime;
		}
	}

	public void HealNeed(Need need, float amount)
	{
		needs[(int)need] += amount;
	}
}
