import { RecipeModel } from "./recipe.model";

export class TypeModel{
    id:number;
    name:string="";
    recipes:RecipeModel[];
}