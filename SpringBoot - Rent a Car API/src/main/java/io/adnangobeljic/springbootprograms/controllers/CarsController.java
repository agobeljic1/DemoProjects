package io.adnangobeljic.springbootprograms.controllers;

import java.util.Arrays;
import java.util.Date;
import java.util.List;
import java.util.Map;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.DeleteMapping;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.PutMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RestController;

@RestController
public class CarsController {
	
	@Autowired
    CarRepository carRepository;
	
	@GetMapping("/cars")
	public List<Car> getAllCars() {		
		return carRepository.findAll();		
	}
	
	@GetMapping("/cars/free")
	public List<Car> getAllFreeCars() {		
	    List<Car> tempList = carRepository.findAll();
	    for(int i=0;i<tempList.size();i++)
	    {
	    	if(!tempList.get(i).isFree())
	    		{
	    		   tempList.remove(i);
	    		   i--;
	    		}
	    }
	    return tempList;
	}
	
	@GetMapping("/cars/taken")
	public List<Car> getAllTakenCars() {		
	    List<Car> tempList = carRepository.findAll();
	    for(int i=0;i<tempList.size();i++)
	    {
	    	if(tempList.get(i).isFree())
	    		{
	    		   tempList.remove(i);
	    		   i--;
	    		}
	    }
	    return tempList;
	}
	
	@GetMapping("/cars/{id}")
	public Car getCar(@PathVariable String id) {	
		Integer carId = Integer.parseInt(id);
		return carRepository.findOne(carId);
	}
	
	@PostMapping("/cars")
	public Car createNewCar(@RequestBody Map<String, String> body) {
		String newName = body.get("name");
		String newManufacturer = body.get("manufacturer");
		double price = Double.parseDouble(body.get("price"));
		int newManufacturing_year = Integer.parseInt(body.get("manufacturing_year"));
		int newNumber_of_seats = Integer.parseInt(body.get("number_of_seats"));
		int newNumber_of_doors = Integer.parseInt(body.get("number_of_doors"));
		String newType_of_fuel = body.get("type_of_fuel");
		boolean newFree = body.get("free")=="true";		
		
		return carRepository.save(new Car(newName,newManufacturer,price,newManufacturing_year,
				                          newNumber_of_seats,newNumber_of_doors,newType_of_fuel,
				                          newFree));  		
	}
	
	@PutMapping("/cars/{id}")
	public Car editCar(@PathVariable String id,@RequestBody Map<String, String> body) {	
		int carId = Integer.parseInt(id);
		
		Car myCar = carRepository.findOne(carId);
		if(body.get("name")!=null)
		    myCar.setName(body.get("name"));
		if(body.get("manufacturer")!=null)
			myCar.setManufacturer(body.get("manufacturer"));
		if(body.get("price")!=null)
			myCar.setPrice(Double.parseDouble(body.get("price")));
		if(body.get("manufacturing_year")!=null)
			myCar.setManufacturing_year(Integer.parseInt(body.get("manufacturing_year")));
		if(body.get("number_of_seats")!=null)
			myCar.setNumber_of_seats(Integer.parseInt(body.get("number_of_seats")));
		if(body.get("number_of_doors")!=null)
			myCar.setNumber_of_doors(Integer.parseInt(body.get("number_of_doors")));
		if(body.get("type_of_fuel")!=null)
			myCar.setType_of_fuel(body.get("type_of_fuel"));
		if(body.get("free")!=null)
			myCar.setFree(body.get("free")=="true");
		
		return carRepository.save(myCar);		
	}
	
	@DeleteMapping("/cars/{id}")
	public boolean deleteCar(@PathVariable String id) {		
		int carId = Integer.parseInt(id);
		carRepository.delete(carId);
		return true;
		
	}
	
	
	
	
	
	

}
