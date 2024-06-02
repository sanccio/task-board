﻿namespace TaskBoard.DAL.Entities;

public class Column
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public ICollection<Card> Cards { get; set; } = new List<Card>();
}
