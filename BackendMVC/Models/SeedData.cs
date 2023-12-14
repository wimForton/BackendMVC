using BackendMVC.Data;
using BackendMVC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Text.Json;

namespace BackendMVC.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new BackendMVCContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<BackendMVCContext>>()))
        {
            // Look for any movies.
            string fileName = "Data/maestro-v3.0.0.json";
            string jsonString = File.ReadAllText(fileName);
            MidiDataObject midiDataObject = JsonSerializer.Deserialize<MidiDataObject>(jsonString)!;


            Console.WriteLine($"versie: {midiDataObject.versie}");
            Console.WriteLine($"Composers: {midiDataObject.canonicalComposer.Count}");


            if (context.MidifileModel.Any())
            {
                //return;//replaced with else   // DB has been seeded
            }
            else
            {
                Console.WriteLine("fill midi database, was empty");
                for (global::System.Int32 i = 0; i < 20; i++)//midiDataObject.canonicalComposer.Count
                {
                    
                    MidifileModel midiObj = new MidifileModel();
                    midiObj.FileNumber = i+1;
                    midiObj.Duration = (int)midiDataObject.duration[i];
                    midiObj.Title = midiDataObject.canonicalTitle[i];
                    midiObj.FilePath = midiDataObject.midiFilename[i];
                    //midiObj.Filesize = 1;
                    string MidiFileName = "MidiData/maestro/" + midiObj.FilePath;
                    Console.WriteLine(MidiFileName);
                    if (File.Exists(MidiFileName))
                    {
                        int size = File.ReadAllBytes(MidiFileName).Length;
                        Console.WriteLine("exists!" + size);
                        midiObj.Filesize = size;
                    }
                    else
                    {
                        midiObj.Filesize = -1;
                    }
                    midiObj.Year = midiDataObject.year[i];
                    midiObj.Composer = midiDataObject.canonicalComposer[i];

                    context.MidifileModel.Add(midiObj);

                }
                context.SaveChanges();
            }
            if (context.Movie.Any())
            {
                //return;//replaced with else   // DB has been seeded
            }
            else
            {
                Console.WriteLine("fill movie database, was empty");
                context.Movie.AddRange(
                    new Movie
                    {
                        Title = "When Harry Met Sally",
                        ReleaseDate = DateTime.Parse("1989-2-12"),
                        Genre = "Romantic Comedy",
                        Rating = "R",
                        Price = 7.99M
                    },
                    new Movie
                    {
                        Title = "Ghostbusters ",
                        ReleaseDate = DateTime.Parse("1984-3-13"),
                        Genre = "Comedy",
                        Rating = "S",
                        Price = 8.99M
                    },
                    new Movie
                    {
                        Title = "Ghostbusters 2",
                        ReleaseDate = DateTime.Parse("1986-2-23"),
                        Genre = "Comedy",
                        Rating = "S",
                        Price = 9.99M
                    },
                    new Movie
                    {
                        Title = "Rio Bravo",
                        ReleaseDate = DateTime.Parse("1959-4-15"),
                        Genre = "Western",
                        Rating = "R",
                        Price = 3.99M
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
