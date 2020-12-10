import { RecipeModel } from "./recipe.model";

export class CuisineModel{
    id:number;
    name:string="";
    recipes:RecipeModel[];
}