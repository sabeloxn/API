from django.db import models

class Food(models.Model):
    fdcId = models.CharField(max_length=100)
    desc = models.CharField(max_length=100)
    brandName = models.CharField(max_length=100)
    # ... other fields

    def __str__(self):
        return self.fdcId