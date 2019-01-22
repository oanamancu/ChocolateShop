using System;
using System.Collections.Generic;
using System.Web;


public class Chocolate
{
    public int id { get; set; }
    public string name { get; set; }
    public string type { get; set; }
    public double price { get; set; }
    public string image { get; set; }
    public string description { get; set; }
    public double weight { get; set; }
    public string dimensions { get; set; }
    public string ingredients { get; set; }
    public string holiday { get; set; }

	public Chocolate(int id, string name, string type, double price, string image, string description, double weight, string dimensions, string ingredients, string holiday)
	{
        this.id = id;
        this.name = name;
        this.type = type;
        this.price = price;
        this.image = image;
        this.description = description;
        this.weight = weight;
        this.dimensions = dimensions;
        this.ingredients = ingredients;
        this.holiday = holiday;
	}

    public Chocolate(string name, string type, double price, string image, string description, double weight, string dimensions, string ingredients, string holiday)
    {
        this.name = name;
        this.type = type;
        this.price = price;
        this.image = image;
        this.description = description;
        this.weight = weight;
        this.dimensions = dimensions;
        this.ingredients = ingredients;
        this.holiday = holiday;
    }

}