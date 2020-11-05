import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Todo } from 'src/_models/todo';

@Injectable({
    providedIn: 'root'
  })
export class TodoService {

baseUrl = environment.apiUrl;
constructor(private http:HttpClient) { }

//connect to web api and get todos on load
getTodos(){
    return this.http.get<Todo[]>(this.baseUrl);
    
}

addTodo(todo:Todo){
    return this.http.post<Todo>(this.baseUrl,todo);
}
}
