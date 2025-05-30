﻿using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace libraryChallenge.Models;

[Table("books", Schema = "library_db")]
public class Book
{
    [Column("id")] public int Id { get; set; }

    [Column("title")] public string Title { get; set; }

    [Column("publicationyear")] public int PublicationYear { get; set; }

    [Column("authorid")] public int AuthorId { get; set; }

    [JsonIgnore] 
    public Author? Author { get; set; } = null!;
}