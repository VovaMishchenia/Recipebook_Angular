import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { RecipeModel } from "../models/recipe.model";
import { Observable } from "rxjs";
import jwt_decode from "jwt-decode";
import { map } from 'rxjs/operators';
import { CuisineModel } from "../models/cuisine.model";
import { TypeModel } from "../models/type.model";
@Injectable({ providedIn: "root" })
export class RecipeService {
    baseUrl = "https://localhost:44344/api/Recipe";
    public recipes: RecipeModel[];
    constructor(private http: HttpClient) {
        this.recipes = this.getAllRecipes();
    }
    addRecipe(model: RecipeModel): void {
        this.http.post<void>(this.baseUrl + "/addRecipe", model).subscribe();

    }
    updateRecipe(model: RecipeModel): void {
        this.http.post<void>(this.baseUrl + "/updateRecipe", model).subscribe();
        this.recipes = this.getAllRecipes();
    }
    getAllRecipes(): RecipeModel[] {
        var token = window.localStorage.getItem("token");
        var decoded = jwt_decode(token);
        console.log(decoded['id']);
        var id = decoded['id'];
        var recipesList = new Array<RecipeModel>();
        this.http.get<RecipeModel[]>(this.baseUrl + `/getRecipes?id=${id}`).subscribe(data => data.forEach(x => { recipesList.push(x); }));


        return recipesList;
    }
    getSearchRecipes(pattern: string): RecipeModel[] {
        var token = window.localStorage.getItem("token");
        var decoded = jwt_decode(token);
        console.log(decoded['id']);
        var id = decoded['id'];
        var recipesList = new Array<RecipeModel>();
        this.http.get<RecipeModel[]>(this.baseUrl + `/searchRecipes?pattern=${pattern}`).subscribe(data => data.forEach(x => { recipesList.push(x); }));
        return recipesList;
    }
    getCuisines(): CuisineModel[] {
        var cuisinesList = new Array<CuisineModel>();
        this.http.get<CuisineModel[]>(this.baseUrl + `/getCuisines`).subscribe(data => data.forEach(x => { cuisinesList.push(x); }));
        return cuisinesList;
    }
    getTypes(): TypeModel[] {
        var typesList = new Array<TypeModel>();
        this.http.get<TypeModel[]>(this.baseUrl + `/getTypes`).subscribe(data => data.forEach(x => { typesList.push(x); }));
        return typesList;
    }
    deleteRecipe(id: number) {
        console.log("delete");
        this.http.post<void>(this.baseUrl + "/deleteRecipe", id).subscribe();
    }
    getRecipes():RecipeModel[] {
        var recipesList = new Array<RecipeModel>();
        this.http.get<RecipeModel[]>(this.baseUrl + `/getAllRecipes`).subscribe(data => data.forEach(x => { recipesList.push(x); }));
        return recipesList;
    }
    
    deleteCuisine(id: number) {
        
        this.http.post<void>(this.baseUrl + "/deleteCuisine", id).subscribe();
    }
    deleteType(id: number) {
        this.http.post<void>(this.baseUrl + "/deleteType", id).subscribe();
    }
    addCuisine(name: string) {
        let model: CuisineModel = new CuisineModel();
        model.name = name;
        this.http.post<void>(this.baseUrl + "/addCuisine", model).subscribe();
    }
    addType(name: string) {
        let model: TypeModel = new TypeModel();
        model.name = name;
        model.recipes= Array<RecipeModel>();
        console.log(model);
        this.http.post<void>(this.baseUrl + "/addType", model).subscribe();
    }

}