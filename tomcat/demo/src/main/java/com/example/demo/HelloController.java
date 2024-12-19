package com.example.demo;

import com.example.demo.entities.GreetingEntity;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.RestController;

@RestController
@RequestMapping("/api")
public class HelloController {
    @Autowired
    private GreetingRepository repository;

    @RequestMapping("/hello")
    public String hello(
            @RequestParam String lang
    ) {
        GreetingEntity entity = this.repository.findFirstByLang(lang);
        return entity.text;
    }
}