#include "filestream.h"

void saveMatrix(Matrix* matrix){
    if (matrix -> exists != false){
        if (strcmp(matrix -> properties, "-1")!=0){
            FILE* file = fopen(matrix->properties,"w");
            fprintf(file, "%d\n", matrix -> size);
            for (int i = 0 ; i < matrix -> size ; i++) {
                for (int j = 0 ; j < matrix -> size ; j++) {
                    fprintf(file, "%d ", matrix -> matrix[i][j]);
            }
            fprintf(file, "\n");
            }
            fclose(file);
            printf("A matrix sikeresen elmentve!\n");
        }else{
            printf("A matrix mar el van tarolva egy fileban!\n");
        }
    }else{
        printf("Meg nem generalt matrixot! A menteshez eloszor generalj matrixot!\n");
    }
}

void loadMatrix(Matrix* matrix){
    printf("Add meg a betoltendo matrix filenevet (spiral/meret/irany/forgas.txt) pl.:spiral10jccw.txt:\n");
    char filename[50];
    scanf("%49s",filename);
    FILE* file = fopen(filename, "r");
    if (file == NULL) {
        printf("Nincs ilyen file!");
    }else{
        int size;
        fscanf(file, "%d", &size);
        matrix -> size = size;
        freeMemoryAllocations(matrix);
        matrix -> matrix = malloc(size* sizeof(int*));
        for (int i = 0 ; i < size ; i++){
            matrix -> matrix[i] = malloc(size * sizeof(int));
            for (int j = 0 ; j < size ; j++){
                fscanf(file, "%d", &matrix -> matrix[i][j]);
            }
        }
        matrix -> exists = true;
        strcpy(matrix -> properties, "-1");
    }
    fclose(file);
}