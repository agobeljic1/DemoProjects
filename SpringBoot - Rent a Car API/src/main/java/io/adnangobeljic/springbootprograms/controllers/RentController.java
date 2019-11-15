package io.adnangobeljic.springbootprograms.controllers;


import java.text.SimpleDateFormat;
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
public class RentController {
	
	/*
	@Autowired
    RentRepository rentRepository;
	@Autowired
    RentRepository rentRepository;
	
	@GetMapping("/rents/active")
	public List<Rent> getAllCurrentRents() {		
		return personRepository.findAll();		
	}
	
	@GetMapping("/rents/archive")
	public List<Rent> getAllArchivedRents() {		
		return personRepository.findAll();		
	}
	
	@GetMapping("/persons/{id}")
	public Person getPerson(@PathVariable String id) {
		int personId = Integer.parseInt(id);
		return personRepository.findOne(personId);
	}	
	
	@PostMapping("/persons")
	public Person createNewPerson (@RequestBody Map<String, String> body)throws Exception {		
		String newName = body.get("name");
		String newSurname = body.get("surname");		
		Date newBirthdate = new SimpleDateFormat("dd-MM-yyyy").parse(body.get("birth_date"));		
				
		return personRepository.save(new Person(newName,newSurname,newBirthdate));		
	}
	
	@PutMapping("/persons/{id}")
	public Person editPerson(@RequestBody Map<String, String> body,@PathVariable String id)throws Exception {
		
		int personId = Integer.parseInt(id);
		Person newPerson = personRepository.findOne(personId);
		if(body.get("name")!=null)
		   newPerson.setName(body.get("name"));
		if(body.get("surname")!=null)
		   newPerson.setName(body.get("surname"));
		if(body.get("birth_date")!=null)
		   newPerson.setBirthDate(new SimpleDateFormat("dd-MM-yyyy").parse(body.get("birth_date")));
							
		return personRepository.save(newPerson);		
	}
	
	@DeleteMapping("/persons/{id}")
	public boolean deletePerson(@PathVariable String id) {
		int personId = Integer.parseInt(id);
		personRepository.delete(personId);
		return true;		
	}*/

}