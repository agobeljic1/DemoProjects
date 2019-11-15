package io.adnangobeljic.springbootprograms.controllers;
import java.util.Date;

import javax.persistence.*;

@Entity
@Table (name="rent")
public class Rent {
	@Id
    @GeneratedValue(strategy = GenerationType.AUTO)
	private int id;
	private int idCar;
	private int idPerson;
	private Date rent;
	

}
