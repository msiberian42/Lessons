﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Models
{
    internal class TodoModel : INotifyPropertyChanged
    {
		[JsonProperty(PropertyName = "creationDate")]
        public DateTime CreationDate { get; set; } = DateTime.Now;

        [JsonProperty(PropertyName = "isDone")]
        public bool IsDone
		{
			get { return _isDone; }
			set 
			{ 
				if (_isDone == value) return;
				_isDone = value;
				OnPropertyChanged("IsDone");
			}
		}

        [JsonProperty(PropertyName = "text")]
        public string Text
		{
			get { return _text; }
			set 
			{
				if (_text == value) return;
				_text = value;
				OnPropertyChanged("Text");
			}
		}

		private bool _isDone;

		private string _text;

        public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged(string propertyName = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
    }
}
