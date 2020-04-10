using Charts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Charts.DAL
{
	public class LocalStorage
	{
		static LocalStorage insatence;
		public static LocalStorage Insatence => insatence ?? (insatence = new LocalStorage());

		private LocalStorage()
		{
			var singers = (List<Singer>)Singers;
			singers.Add(new Singer() { Name = "Гражданская оборона" });
			singers.Add(new Singer() { Name = "Кино" });
			singers.Add(new Singer() { Name = "Би-2" });
			singers.Add(new Singer() { Name = "Linkin Park" });
			singers.Add(new Singer() { Name = "Bring me the horizont" });
			singers.Add(new Singer() { Name = "Lolita" });
			singers.Add(new Singer() { Name = "Oxxxymiron" });

			var genres = (List<Genre>)Genres;
			genres.Add(new Genre { Name = "Рок" });
			genres.Add(new Genre { Name = "Альтернативный рок" });
			genres.Add(new Genre { Name = "Поп" });
			genres.Add(new Genre { Name = "Рэп" });

			var tracks = (List<Track>)Tracks;
			tracks.Add(new Track { Name = "EEE" });
			tracks.Add(new Track { Name = "Моя оборона" });
			((List<Track>)singers[0].Tracks).AddRange(tracks.Take(2));
			((List<Track>)genres[0].Tracks).AddRange(tracks.Take(2));

			((List<Singer>)tracks[0].Singers).AddRange(singers.Take(0));
			//((List<Genre>)tracks[0].Genre).AddRange(genres.Take(1));


			tracks.Add(new Track { Name = "Кукушка" });
			tracks.Add(new Track { Name = "Группа крови" });
			tracks.Add(new Track { Name = "Восьмикласница" });
			tracks.Add(new Track { Name = "Видели ночь" });
			tracks.Add(new Track { Name = "Звезда" });
			tracks.Add(new Track { Name = "Перемен" });

			((List<Track>)singers[1].Tracks).AddRange(tracks.Skip(2).Take(6));
			((List<Track>)genres[0].Tracks).AddRange(tracks.Skip(2).Take(6));

			foreach (var item in tracks.Skip(2).Take(6))
			{
				((List<Singer>)item.Singers).Add(singers[1]);
				//((List<Genre>)item.Genre).Add(genres[0]);
			}

			((List<Track>)singers[1].Tracks).AddRange(tracks.Take(2));
			((List<Track>)genres[0].Tracks).AddRange(tracks.Take(2));

			//foreach (var item in tracks.Skip(2).Take(6))
			//{
			//    ((List<Singer>))
			//}
			((List<Singer>)tracks[2].Singers).AddRange(singers.Take(1));
			((List<Singer>)tracks[3].Singers).AddRange(singers.Take(1));
			((List<Singer>)tracks[4].Singers).AddRange(singers.Take(1));
			((List<Singer>)tracks[5].Singers).AddRange(singers.Take(1));
			((List<Singer>)tracks[6].Singers).AddRange(singers.Take(1));
			((List<Singer>)tracks[7].Singers).AddRange(singers.Take(1));
			//((List<Genre>)tracks[8].Genre).AddRange(genres.Take(0));


		}

		public IEnumerable<Track> Tracks = new List<Track>();
		public IEnumerable<Singer> Singers = new List<Singer>();
		public IEnumerable<Genre> Genres = new List<Genre>();
	}
}
