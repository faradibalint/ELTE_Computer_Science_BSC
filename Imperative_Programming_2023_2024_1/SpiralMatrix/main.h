#ifndef MAIN_SPIRALMATRIX
#define MAIN_SPIRALMATRIX

#include <stdio.h>
#include <stdlib.h>
#include <stdbool.h>
#include <string.h>

typedef enum _Choice Choice;
typedef struct _Matrix Matrix;

enum _Choice{
    Guide,
    Generate,
    Save,
    Load,
    Print,
    Exit,
    NUL
};

struct _Matrix{
    int** matrix;
    int size;
    bool exists;
    char properties[20];
};

void callGuide();
void freeMemoryAllocations(Matrix* matrix);


#endif // MAIN_SPIRALMATRIX