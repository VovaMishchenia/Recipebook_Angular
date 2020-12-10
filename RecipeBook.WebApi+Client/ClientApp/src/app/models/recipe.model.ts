export class RecipeModel {
    id: number;
    name: string="";
    ingredients: string="";
    photoPath: string="";
    instruction: string="";
    cuisine: string="";
    type: string="";
    cookingTime: number=0;
    rating: number=1;
    calories: number=0;
    cuisineId: number;
    typeId: number;
}
