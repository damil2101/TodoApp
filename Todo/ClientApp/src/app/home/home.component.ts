import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Todo } from 'src/_models/todo';
import { AlertifyService } from 'src/_services/alertify.service';
import { TodoService } from 'src/_services/todo.service';

@Component({
  selector: 'app-todo',
  templateUrl: './home.component.html'
})
export class HomeComponent implements OnInit {

  todos:Todo[];
  TodoAddForm:FormGroup;
  todoDesc:string;
  
  constructor(private todoService:TodoService,private fb:FormBuilder, private alertify:AlertifyService) { }

  ngOnInit() {
    // Load all Todo items on page load
    this.todoService.getTodos()
    .subscribe((data)=> {
      this.todos = data;
    },(error) => {
      this.alertify.error(error);
    })
    this.AddTodoForm();
  }

  AddTodoForm() {
    this.TodoAddForm = this.fb.group({
      todo:['',Validators.required]
    });
  }

  addTodo(){
    // Adding a new todo item
    if(this.TodoAddForm.valid){
      this.todoDesc = this.TodoAddForm.value['todo'];
      this.todoService.addTodo({
        id : this.todos.length + 1,
        description : this.todoDesc
      }).subscribe((response) => {
        //append the last added Todo to the list
        this.todos.push(response);
        this.alertify.success("Item Added Successfully");
        this.TodoAddForm.reset();
      });
      
  }
}
}
