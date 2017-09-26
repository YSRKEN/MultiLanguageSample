using MultiLanguageSample.Properties;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace WsGH {
	public class ResourceService : INotifyPropertyChanged {
		#region シングルトン対策
		private static readonly ResourceService current = new ResourceService();
		public static ResourceService Current => current;
		#endregion

		#region INotifyPropertyChanged対策
		public event PropertyChangedEventHandler PropertyChanged;
		protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null) {
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
		#endregion

		/// <summary>
		/// リソースを取得
		/// </summary>
		private readonly Resources resources = new Resources();
		public Resources Resources => resources;

		/// <summary>
		/// リソースのカルチャーを変更
		/// </summary>
		/// <param name="name">カルチャー名</param>
		public void ChangeCulture(string name) {
			Resources.Culture = CultureInfo.GetCultureInfo(name);
			RaisePropertyChanged("Resources");
		}
	}
}
