export class RecipeTransferModel {
    Id: number;
    Name: string="";
    Ingredients: string="";
    PhotoPath: string="";
    Instruction: string="";
    Cuisine: string="";
    Type: string="";
    CookingTime: number=0;
    Rating: number=1;
    Calories: number=0;
    CuisineId: number;
    TypeId: number;
}