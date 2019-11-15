package io.adnangobeljic.springbootprograms.controllers;
import javax.persistence.*;

import java.io.Serializable;
import java.util.Date;

@Entity
@Table (name="car")
public class Car implements Serializable {
	
	@Id
    @GeneratedValue(strategy = GenerationType.AUTO)
	private int id;
	
	private String name;
	private String manufacturer;
	private double price;
	private int manufacturing_year;
	private int number_of_seats;
	private int number_of_doors;
	private String type_of_fuel;
	private boolean free;
	

	public Car(int id, String name, String manufacturer, int manufacturing_year, double price) {
		super();
		this.id = id;
		this.name = name;
		this.manufacturer = manufacturer;
		this.manufacturing_year = manufacturing_year;
		this.price = price;
		this.free = true;
	}

	public Car() {}

	public Car(int id, String name, String manufacturer, double price, int manufacturing_year, int number_of_seats, int number_of_doors,
			String type_of_fuel) {
		super();
		this.id = id;
		this.name = name;
		this.manufacturer = manufacturer;
		this.price = price;
		this.manufacturing_year = manufacturing_year;
		this.number_of_seats = number_of_seats;
		this.number_of_doors = number_of_doors;
		this.type_of_fuel = type_of_fuel;
		this.free = true;
	}

	public Car(int id, String name, String manufacturer, double price, int manufacturing_year, int number_of_seats,
			int number_of_doors, String type_of_fuel, boolean free) {
		super();
		this.id = id;
		this.name = name;
		this.manufacturer = manufacturer;
		this.price = price;
		this.manufacturing_year = manufacturing_year;
		this.number_of_seats = number_of_seats;
		this.number_of_doors = number_of_doors;
		this.type_of_fuel = type_of_fuel;
		this.free = free;
	}
	public Car(String name, String manufacturer, double price, int manufacturing_year, int number_of_seats,
			int number_of_doors, String type_of_fuel, boolean free) {
		super();
		this.name = name;
		this.manufacturer = manufacturer;
		this.price = price;
		this.manufacturing_year = manufacturing_year;
		this.number_of_seats = number_of_seats;
		this.number_of_doors = number_of_doors;
		this.type_of_fuel = type_of_fuel;
		this.free = free;
	}
	

	public int getId() {
		return id;
	}

	public void setId(int id) {
		this.id = id;
	}

	public String getName() {
		return name;
	}

	public void setName(String name) {
		this.name = name;
	}

	public String getManufacturer() {
		return manufacturer;
	}

	public void setManufacturer(String manufacturer) {
		this.manufacturer = manufacturer;
	}
	
	public double getPrice() {
		return price;
	}

	public void setPrice(double price) {
		this.price = price;
	}

	public int getManufacturing_year() {
		return manufacturing_year;
	}

	public void setManufacturing_year(int manufacturing_year) {
		this.manufacturing_year = manufacturing_year;
	}

	public int getNumber_of_seats() {
		return number_of_seats;
	}

	public void setNumber_of_seats(int number_of_seats) {
		this.number_of_seats = number_of_seats;
	}

	public int getNumber_of_doors() {
		return number_of_doors;
	}

	public void setNumber_of_doors(int number_of_doors) {
		this.number_of_doors = number_of_doors;
	}

	public String getType_of_fuel() {
		return type_of_fuel;
	}

	public void setType_of_fuel(String type_of_fuel) {
		this.type_of_fuel = type_of_fuel;
	}

	

	public boolean isFree() {
		return free;
	}

	public void setFree(boolean free) {
		this.free = free;
	}
	
	

}
