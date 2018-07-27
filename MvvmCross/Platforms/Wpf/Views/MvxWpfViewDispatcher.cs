﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MS-PL license.
// See the LICENSE file in the project root for more information.

using System.Threading.Tasks;
using System.Windows.Threading;
using MvvmCross.Platforms.Wpf.Presenters;
using MvvmCross.ViewModels;
using MvvmCross.Views;

namespace MvvmCross.Platforms.Wpf.Views
{
    public class MvxWpfViewDispatcher
        : MvxWpfUIThreadDispatcher, IMvxViewDispatcher
    {
        private readonly IMvxWpfViewPresenter _presenter;

        public MvxWpfViewDispatcher(Dispatcher dispatcher, IMvxWpfViewPresenter presenter)
            : base(dispatcher)
        {
            _presenter = presenter;
        }

        public async Task<bool> ShowViewModel(MvxViewModelRequest request)
        {
            await ExecuteOnMainThreadAsync(() => _presenter.Show(request));
            return true;
        }

        public async Task<bool> ChangePresentation(MvxPresentationHint hint)
        {
            await ExecuteOnMainThreadAsync(() => _presenter.ChangePresentation(hint));
            return true;
        }
    }
}