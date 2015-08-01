using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Threading;

/*
 * 
 * Code from http://stackoverflow.com/questions/30425283/binding-source-not-reflecting-new-removed-row-when-list-datasource-adds-removes/30446089#30446089
 * and https://groups.google.com/forum/#!msg/microsoft.public.dotnet.languages.csharp/IU5ViEsW9Nk/Bn9WgFk8KvEJ
 */
namespace ProxyMaid
{
    public class ThreadedBindingList<T> : BindingList<T>
    {

        public SynchronizationContext SynchronizationContext
        {
            get { return _ctx; }
            set { _ctx = value; }
        }

        SynchronizationContext _ctx;
        protected override void OnAddingNew(AddingNewEventArgs e)
        {
            if (_ctx == null)
            {
                BaseAddingNew(e);
            }
            else
            {
                SynchronizationContext.Current.Send(delegate
                {
                    BaseAddingNew(e);
                }, null);
            }
        }
        void BaseAddingNew(AddingNewEventArgs e)
        {
            base.OnAddingNew(e);
        }
        protected override void OnListChanged(ListChangedEventArgs e)
        {
            if (_ctx == null)
            {
                BaseListChanged(e);
            }
            else
            {
                _ctx.Send(delegate { BaseListChanged(e); }, null);
            }
        }
        void BaseListChanged(ListChangedEventArgs e)
        {
            base.OnListChanged(e);
        }
    }
}
